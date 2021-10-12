﻿using System;
using HraveMzdy.Procezor.Service.Interfaces;
using HraveMzdy.Procezor.Service.Types;
using ProcezorTests.Registry.Constants;

namespace ProcezorTests.Registry.Providers
{
    class TestTermResult : TermResult
    {
        public TestTermResult(ITermTarget target, Int32 value, Int32 basis, string descr) : base(target, basis, value, descr)
        {
        }
        public override string ArticleDescr()
        {
            return Target?.ArticleEnumDescr<TestArticleConst>();
        }
        public override string ConceptDescr()
        {
            return Target?.ConceptEnumDescr<TestConceptConst>();
        }
    }
}