using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class PeakAndDetectObjectActionGoal : ActionGoal<PeakAndDetectObjectGoal>
    {
        public const string k_RosMessageName = "webots_spot_msgs/PeakAndDetectObjectActionGoal";
        public override string RosMessageName => k_RosMessageName;


        public PeakAndDetectObjectActionGoal() : base()
        {
            this.goal = new PeakAndDetectObjectGoal();
        }

        public PeakAndDetectObjectActionGoal(HeaderMsg header, GoalIDMsg goal_id, PeakAndDetectObjectGoal goal) : base(header, goal_id)
        {
            this.goal = goal;
        }
        public static PeakAndDetectObjectActionGoal Deserialize(MessageDeserializer deserializer) => new PeakAndDetectObjectActionGoal(deserializer);

        PeakAndDetectObjectActionGoal(MessageDeserializer deserializer) : base(deserializer)
        {
            this.goal = PeakAndDetectObjectGoal.Deserialize(deserializer);
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
