using System;
using System.Collections.Generic;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;

namespace HraveMzdy.Procezor.Service.Providers
{
    public class ArticleSpec : IArticleSpec
    {
        public IEnumerable<ArticleCode> Sums { get; protected set; }

        public ConceptCode Role { get; protected set; }

        public ArticleCode Code { get; protected set; }

        public IArticleDefine Defs()
        {
            return new ArticleDefine(Code.Value, Role.Value);
        }

        public ArticleSpec(Int32 code, Int32 role)
        {
            Code = new ArticleCode(code);

            Role = new ConceptCode(role);
        }
        public int CompareTo(object obj)
        {
            IArticleSpec other = obj as IArticleSpec;

            return (this.Code.CompareTo(other.Code));
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            IArticleSpec other = obj as IArticleSpec;

            return (this.Code.Equals(other.Code));
        }

        public override int GetHashCode()
        {
            int result = this.Code.GetHashCode();

            return result;
        }
    }
}
