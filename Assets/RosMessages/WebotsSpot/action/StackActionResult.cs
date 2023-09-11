using System.Collections.Generic;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;
using RosMessageTypes.Std;
using RosMessageTypes.Actionlib;

namespace RosMessageTypes.WebotsSpot
{
    public class StackActionResult : ActionResult<StackResult>
    {
        public const string k_RosMessageName = "webots_spot_msgs/StackActionResult";
        public override string RosMessageName => k_RosMessageName;


        public StackActionResult() : base()
        {
            this.result = new StackResult();
        }

        public StackActionResult(HeaderMsg header, GoalStatusMsg status, StackResult result) : base(header, status)
        {
            this.result = result;
        }
        public static StackActionResult Deserialize(MessageDeserializer deserializer) => new StackActionResult(deserializer);

        StackActionResult(MessageDeserializer deserializer) : base(deserializer)
        {
            this.result = StackResult.Deserialize(deserializer);
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
