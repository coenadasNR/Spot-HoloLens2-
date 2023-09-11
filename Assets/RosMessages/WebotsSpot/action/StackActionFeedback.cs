using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class StackActionFeedback : ActionFeedback<StackFeedback>
    {
        public const string k_RosMessageName = "webots_spot_msgs/StackActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public StackActionFeedback() : base()
        {
            this.feedback = new StackFeedback();
        }

        public StackActionFeedback(HeaderMsg header, GoalStatusMsg status, StackFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static StackActionFeedback Deserialize(MessageDeserializer deserializer) => new StackActionFeedback(deserializer);

        StackActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = StackFeedback.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.feedback);
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
