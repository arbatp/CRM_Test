using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Workflow;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomWorkflow
{
    

    public class Class1 : CodeActivity
    {

        [Input("VDateOfBirth")]
        public InArgument<DateTime> VDateOfBirth { get; set; }
        [Output("VAge")]
        public OutArgument <int> VAge { get; set; }

        //[Input("name")]
        //public InArgument<string> name  { get; set; }

        //[Output("Policyname")]
        //public OutArgument<string> policyname  { get; set; }

        protected override void Execute(CodeActivityContext context)
        {


            IWorkflowContext workflowContext = context.GetExtension<IWorkflowContext>();
            IOrganizationServiceFactory factory = context.GetExtension<IOrganizationServiceFactory>();
            IOrganizationService service = factory.CreateOrganizationService(workflowContext.UserId);

            var currentdate = DateTime.Now.Year;
            var DOB = VDateOfBirth.Get(context);
            var age = currentdate - DOB.Year;

           

            DateTime finalage = VDateOfBirth.Get(context);
            VAge.Set(context, age);

            // IWorkflowContext workflowcontext = context.GetExtension<IWorkflowContext>();

            // IOrganizationServiceFactory factory = context.GetExtension<IOrganizationServiceFactory>();

            // IOrganizationService service = factory.CreateOrganizationService(workflowcontext.UserId);

            // string name1 = name.Get(context);
            // policyname.Set(context, name1);
            ////throw new NotImplementedException();
        }
    }
}
