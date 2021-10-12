using System;
using HraveMzdy.Procezor.Service.Interfaces;

namespace HraveMzdy.Procezor.Service.Types
{
    public class ArticleDefine : IArticleDefine
    {
        public ArticleCode Code { get; }
        public ConceptCode Role { get; }
        public ArticleDefine()
        {
            Code = ArticleCode.New();

            Role = ConceptCode.New();
        }
        public ArticleDefine(Int32 code, Int32 role)
        {
            Code = new ArticleCode(code);

            Role = new ConceptCode(role);
        }
        public ArticleDefine(Int32 code)
        {
            Code = new ArticleCode(code);

            Role = ConceptCode.New();
        }
        public ArticleDefine(IArticleDefine define)
        {
            Code = define.Code;

            Role = define.Role;
        }
        public int CompareTo(object obj)
        {
            IArticleDefine other = obj as IArticleDefine;

            return (this.Code.CompareTo(other.Code));
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            IArticleDefine other = obj as IArticleDefine;

            return (this.Code.Equals(other.Code));
        }

        public override int GetHashCode()
        {
            int result = this.Code.GetHashCode();

            return result;
        }
    }
}
