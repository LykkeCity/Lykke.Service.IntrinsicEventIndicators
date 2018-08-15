// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.IntrinsicEventIndicators.Client.AutorestClient.Models
{
    using Microsoft.Rest;
    using Newtonsoft.Json;
    using System.Linq;

    public partial class IntrinsicEventIndicatorsRowPost
    {
        /// <summary>
        /// Initializes a new instance of the IntrinsicEventIndicatorsRowPost
        /// class.
        /// </summary>
        public IntrinsicEventIndicatorsRowPost()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IntrinsicEventIndicatorsRowPost
        /// class.
        /// </summary>
        public IntrinsicEventIndicatorsRowPost(string exchange, string assetPair, string pairName)
        {
            Exchange = exchange;
            AssetPair = assetPair;
            PairName = pairName;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Exchange")]
        public string Exchange { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "AssetPair")]
        public string AssetPair { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "PairName")]
        public string PairName { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            if (Exchange == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Exchange");
            }
            if (AssetPair == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "AssetPair");
            }
            if (PairName == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "PairName");
            }
        }
    }
}
