using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptCs;
using ScriptCs.Contracts;

namespace ScriptCs.SampleModule
{
    [Module("sample", Extensions = "csx")]
    public class SampleModule : IModule
    {
        public void Initialize(IModuleConfiguration config)
        {
            config.LineProcessor<TestDirectiveLineProcessor>();
            Console.WriteLine("SAMPLE module initialized");
        }
    }

    public class TestDirectiveLineProcessor : DirectiveLineProcessor
    {
        public TestDirectiveLineProcessor()
        {
            Console.Write("TestDirectiveLineProcessor .ctor");
        }

        protected override string DirectiveName
        {
            get { return "test"; }
        }

        protected override bool ProcessLine(IFileParser parser, FileParserContext context, string line)
        {
            if (line.Trim(' ').StartsWith("#" + DirectiveName))
            {
                Console.WriteLine("TestDirectiveLineProcessor triggered : " + line);
                return true;
            }

            return false;
        } 
    }
}
