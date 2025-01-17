#pragma checksum "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "65c4864c3311b7d6d41636e2a3a684dc449c2db6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\_ViewImports.cshtml"
using AviationEducation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\_ViewImports.cshtml"
using AviationEducation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"65c4864c3311b7d6d41636e2a3a684dc449c2db6", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33f8f5778aac038f510785c657470f8b1a17bbf6", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Question>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\Home\Index.cshtml"
  
    //Make first question random from the model list.
    Random rnd = new Random();
    int r = rnd.Next(Model.Count);
    Question currentQuestion = Model.ElementAt(r);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Welcome</h1>
    <p>Random 10 question quiz. If you want to customize, please register</p>
    <input type=""button"" class=""btn btn-warning"" id=""start_button"" onclick=""Start(this)"" value=""Start Quiz"" />
    <div id=""quiz_div"" style=""display: none"">
        <p id=""question_text"" class=""lead font-weight-bold""></p>
        <p id=""option1"" onclick=""Option_clicked(this)""></p>
        <p id=""option2"" onclick=""Option_clicked(this)""></p>
        <p id=""option3"" onclick=""Option_clicked(this)""></p>
        <input type=""button"" id=""next_question_button"" class=""btn btn-warning"" onclick=""NextQuestion()"" value=""Next question"" />
        <p id=""score"" class=""mt-2"">Score: 0/0</p>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\">\r\n\r\n        //All questions from model\r\n        var questions = ");
#nullable restore
#line 34 "C:\Users\Dellas\source\repos\AviationEducation\AviationEducation\Views\Home\Index.cshtml"
                   Write(Html.Raw(Json.Serialize(Model)));

#line default
#line hidden
#nullable disable
                WriteLiteral(@";

        //Main variables and manipulated HTML elements
        var score = 0
        var total_questions_answered = 0
        var current_question
        var question_el = document.getElementById('question_text')
        var option1_el = document.getElementById('option1')
        var option2_el = document.getElementById('option2')
        var option3_el = document.getElementById('option3')
        var next_button_el = document.getElementById('next_question_button')

        // ********************** Start button *********************

        function Start(button) {
            //Hide and appear needed HTML
            document.getElementById('quiz_div').style.display = ""inline"";
            button.style.display = ""none"";
            next_button_el.disabled = true;
            //Pick randonm question and put it into HTML
            current_question = questions[Math.floor(Math.random() * questions.length)];
            question_el.innerHTML = current_question['question_Text']
      ");
                WriteLiteral(@"      option1_el.innerHTML = current_question['option1']
            option2_el.innerHTML = current_question['option2']
            option3_el.innerHTML = current_question['option3']
            //Re-start needed styles
            for (let i of [option1_el, option2_el, option3_el]) {
                i.style.background = """";
                i.style.cursor = ""pointer"";
                i.style.pointerEvents = ""auto"";
            }
            //Display score
            document.getElementById('score').innerHTML = ""Score: "" + score + "" /"" + total_questions_answered
            }

        //********************** Option click event *********************

            function Option_clicked(object) {
            next_button_el.disabled = false
            total_questions_answered += 1
            //Check if clicked option is correct
            if (object.innerHTML == current_question['answer']) {
                score += 1
                object.style.background = ""#009933"";
            }
");
                WriteLiteral(@"            else {
                for (let i of [option1_el, option2_el, option3_el]) {
                    if (i.innerHTML == current_question.answer) {
                        i.style.background = ""#009933"";
                    }
                }
            }
            for (let i of [option1_el, option2_el, option3_el]) {
                i.style.cursor = ""default"";
                i.style.pointerEvents = ""none"";
            }
            //Update score HTML
            document.getElementById('score').innerHTML = ""Score: "" + score + "" /"" + total_questions_answered
            //If it's last question buton text is Finish
            if (total_questions_answered == 10) {
                next_button_el.value = ""Finish""
            }
        }

        //********************** Next Question button *********************

        function NextQuestion()
        {
            next_button_el.disabled = true;
            //Restart html styles for questions
            for (let i of [opt");
                WriteLiteral(@"ion1_el, option2_el, option3_el]) {
                i.style.background = """";
                i.style.pointerEvents = ""auto"";
                i.style.cursor = ""pointer"";
            }
            //Pick new random question and update HTML
            current_question = questions[Math.floor(Math.random() * questions.length)];
            question_el.innerHTML = current_question['question_Text']
            option1_el.innerHTML = current_question['option1']
            option2_el.innerHTML = current_question['option2']
            option3_el.innerHTML = current_question['option3']

            if (total_questions_answered == 10) {
                //restart data
                score = 0
                total_questions_answered = 0
                //hide/appear needed HTML
                document.getElementById('quiz_div').style.display = ""none"";
                document.getElementById('start_button').style.display = ""inline"";
            }
        }
    </script>

");
            }
            );
            WriteLiteral("\r\n\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Question>> Html { get; private set; }
    }
}
#pragma warning restore 1591
