// <auto-generated>
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Lykke.Service.IncreasticEventIndicators.Client.AutorestClient.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class IntrinsicEventIndicatorsColumnDto
    {
        /// <summary>
        /// Initializes a new instance of the IntrinsicEventIndicatorsColumnDto
        /// class.
        /// </summary>
        public IntrinsicEventIndicatorsColumnDto()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the IntrinsicEventIndicatorsColumnDto
        /// class.
        /// </summary>
        public IntrinsicEventIndicatorsColumnDto(double value, string columnId = default(string))
        {
            ColumnId = columnId;
            Value = value;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "ColumnId")]
        public string ColumnId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "Value")]
        public double Value { get; set; }

        /// <summary>
        /// Validate the object.
        /// </summary>
        /// <exception cref="Microsoft.Rest.ValidationException">
        /// Thrown if validation fails
        /// </exception>
        public virtual void Validate()
        {
            //Nothing to validate
        }
    }
}
