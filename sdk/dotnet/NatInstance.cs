// *** WARNING: this file was generated by pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;
using Pulumi;

namespace PiersKarsenbarg.Fcknat
{
    [FcknatResourceType("fcknat:index:NatInstance")]
    public partial class NatInstance : global::Pulumi.ComponentResource
    {
        /// <summary>
        /// Instance Id of the EC2 instance
        /// </summary>
        [Output("instanceId")]
        public Output<string> InstanceId { get; private set; } = null!;

        [Output("subnetId")]
        public Output<string> SubnetId { get; private set; } = null!;


        /// <summary>
        /// Create a NatInstance resource with the given unique name, arguments, and options.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resource</param>
        /// <param name="args">The arguments used to populate this resource's properties</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public NatInstance(string name, NatInstanceArgs args, ComponentResourceOptions? options = null)
            : base("fcknat:index:NatInstance", name, args ?? new NatInstanceArgs(), MakeResourceOptions(options, ""), remote: true)
        {
        }

        private static ComponentResourceOptions MakeResourceOptions(ComponentResourceOptions? options, Input<string>? id)
        {
            var defaultOptions = new ComponentResourceOptions
            {
                Version = Utilities.Version,
                PluginDownloadURL = "github://api.github.com/pierskarsenbarg/pulumi-fcknat",
            };
            var merged = ComponentResourceOptions.Merge(defaultOptions, options);
            // Override the ID if one was specified for consistency with other language SDKs.
            merged.Id = id ?? merged.Id;
            return merged;
        }
    }

    public sealed class NatInstanceArgs : global::Pulumi.ResourceArgs
    {
        /// <summary>
        /// CIDR blocks that you want the NAT instance to be available to. Will use the CIDR block for the VPC otherwise
        /// </summary>
        [Input("cidr")]
        public Input<string>? Cidr { get; set; }

        /// <summary>
        /// Instance type of the NAT instance
        /// </summary>
        [Input("instanceType", required: true)]
        public Input<string> InstanceType { get; set; } = null!;

        /// <summary>
        /// Public subnet ID where the NAT instance will be created. If not specified then one will be selected from the VPC.
        /// </summary>
        [Input("subnetId")]
        public Input<string>? SubnetId { get; set; }

        /// <summary>
        /// Id of the VPC that the NAT instance will be inside. Will select the default VPC for the region if not set.
        /// </summary>
        [Input("vpcId")]
        public Input<string>? VpcId { get; set; }

        public NatInstanceArgs()
        {
        }
        public static new NatInstanceArgs Empty => new NatInstanceArgs();
    }
}
