using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class PeakAndDetectObjectActionResult : ActionResult<PeakAndDetectObjectResult>
    {
        public const string k_RosMessageName = "webots_spot_msgs/PeakAndDetectObjectActionResult";
        public override string RosMessageName => k_RosMessageName;


        public PeakAndDetectObjectActionResult() : base()
        {
            this.result = new PeakAndDetectObjectResult();
        }

        public PeakAndDetectObjectActionResult(HeaderMsg header, GoalStatusMsg status, PeakAndDetectObjectResult result) : base(header, status)
        {
            this.result = result;
        }
        public static PeakAndDetectObjectActionResult Deserialize(MessageDeserializer deserializer) => new PeakAndDetectObjectActionResult(deserializer);

        PeakAndDetectObjectActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = PeakAndDetectObjectResult.Deserialize(deserializer);
        }
        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.header);
            serializer.Write(this.status);
            serializer.Write(this.result);
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
