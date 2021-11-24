namespace Portefeuille.Data.Entities
{
    public partial class ClientEntity 
    {
        #region Properties
        public virtual long Id { get; set; }

        public virtual string ShortName { get; set; }

        public virtual string Number { get; set; }

        public virtual string ClientCurrency { get; set; }

        public virtual string LongName { get; set; }

        public virtual string IsDiscretionary { get; set; }

        public virtual string ClassCode { get; set; }

        public virtual string Email1 { get; set; }

        public virtual string Email2 { get; set; }

        public virtual string Email3 { get; set; }

        public virtual string NAS { get; set; }

        public virtual string Telephone1 { get; set; }

        public virtual string Telephone2 { get; set; }

        public virtual string Telephone3 { get; set; }

        public virtual string Telephone4 { get; set; }

        public virtual long FirmId { get; set; }

        public virtual string InvestmentAdvisorCode { get; set; }
        #endregion

        ///// <summary>
        ///// Mapping
        ///// </summary>
        //public class Map : ClassMap<ClientEntity>
        //{
        //    /// <summary>
        //    /// Constructor.
        //    /// </summary>
        //    public Map()
        //    {
        //        Table("B_CLIENT");
        //        BatchSize(100);
        //        Id(x => x.Id).Column("CLIENT_ID");

        //        Map(x => x.ShortName).Column("NOM").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Number).Column("NO_CLIENT").CustomType<TrimmedStringUserType>();
        //        Map(x => x.ClientCurrency).Column("CURRENCY").CustomType<TrimmedStringUserType>();
        //        Map(x => x.LongName).Column("NOMLONG").CustomType<TrimmedStringUserType>();
        //        Map(x => x.IsDiscretionary).Column("IS_DISCRETIONARY");
        //        Map(x => x.ClassCode).Column("CLASSE").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Email1).Column("EMAIL1");
        //        Map(x => x.Email2).Column("EMAIL2");
        //        Map(x => x.Email3).Column("EMAIL3");
        //        Map(x => x.NAS).Column("N_A_S").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Telephone1).Column("TEL1").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Telephone2).Column("TEL2").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Telephone3).Column("TEL3").CustomType<TrimmedStringUserType>();
        //        Map(x => x.Telephone4).Column("TEL4").CustomType<TrimmedStringUserType>();
        //        Map(x => x.FirmId).Column("FIRM_ID");
        //        Map(x => x.InvestmentAdvisorCode).Column("NO_REP");
        //    }
        //}
    }
}
