//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AdamDal
{
    using System;
    using System.Collections.Generic;
    using System.Web.Script.Serialization;
    
    public partial class Product_Specification
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public string Value { get; set; }
    [ScriptIgnore]
        public virtual Product Product { get; set; }
        public virtual Specification Specification { get; set; }
    }
}
