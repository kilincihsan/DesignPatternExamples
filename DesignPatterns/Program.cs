using Builders;
using Builders.BuilderPattern_HTMLBuilder1;
using Builders.FacetedBuilder_CV;
using Builders.OrdinaryBuilderPattern_HTMLBuilder2;
using Builders.StepBuilderPattern_ChessMoveBuilder;
using DesignPatternExamples.Builders.PersonBuilder1;
using DesignPatternExamples.Builders.PersonBuilder2;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        #region Builder Design Patterns
        /* string builder */
        StringBuilder1.Execute();

        /* non-fluent builder pattern - HTML builder example to see how it goes without chaining */
        BuilderPattern_HTMLBuilder1.Execute();

        /* fluent builder pattern - HTML builder example to see chaining builders to make them fluent */
        BuilderPattern_HTMLBuilder2.Execute();

        /* builder pattern - person builder example */
        BuilderPattern_PersonBuilder1.Execute();

        /* more seperated, inherited version for OOP - person builder inherited example 
         context: using inheritance with builders is causing problems when you want to use them fluently
        because you have to cast them to the base class to use them fluently.
        here is an example of how to use them fluently with inheritance
         */
        BuilderPattern_PersonBuilder2.Execute();

        /* faceted builder */
        FacetedBuilder_CVBuilder.Execute();

        /* stepwise chess move builder */
        StepBuilderPattern_ChessMoveBuilder.Execute();
        #endregion
    }
}