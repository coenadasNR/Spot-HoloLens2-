using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class PeakAndDetectObjectActionFeedback : ActionFeedback<PeakAndDetectObjectFeedback>
    {
        public const string k_RosMessageName = "webots_spot_msgs/PeakAndDetectObjectActionFeedback";
        public override string RosMessageName => k_RosMessageName;


        public PeakAndDetectObjectActionFeedback() : base()
        {
            this.feedback = new PeakAndDetectObjectFeedback();
        }

        public PeakAndDetectObjectActionFeedback(HeaderMsg header, GoalStatusMsg status, PeakAndDetectObjectFeedback feedback) : base(header, status)
        {
            this.feedback = feedback;
        }
        public static PeakAndDetectObjectActionFeedback Deserialize(MessageDeserializer deserializer) => new PeakAndDetectObjectActionFeedback(deserializer);

        PeakAndDetectObjectActionFeedback(MessageDeserializer deserializer) : base(deserializer)
        {
            this.feedback = PeakAndDetectObjectFeedback.Deserialize(deserializer);
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
