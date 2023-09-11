using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class StackActionGoal : ActionGoal<StackGoal>
    {
        public const string k_RosMessageName = "webots_spot_msgs/StackActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public StackActionGoal() : base()
        {
            this.goal = new StackGoal();
        }

        public StackActionGoal(HeaderMsg header, GoalIDMsg goal_id, StackGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static StackActionGoal Deserialize(MessageDeserializer deserializer) => new StackActionGoal(deserializer);

        StackActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = StackGoal.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.goal_id);
            serializer.Write(this.goal);
        }


#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
