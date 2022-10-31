using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BMI.Tests
{
    public class BmiCalculatorFacadeTestsData : IEnumerable<object[]>
    {
        private const string UNDERWIGHT_SUMMARY_TEXT = "You are underweight, you should put on some weight";
        private const string NORMAL_SUMMARY_TEXT = "Your weight is normal, keep it up";
        private const string OVERWEIGHT_SUMMARY_TEXT = "You are a bit overweight";
        private const string OBESITY_SUMMARY_TEXT = "You should take care of your obesity";
        private const string EXTREMEOBESITY_SUMMARY_TEXT = "Your extreme obesity might cause health problems";

        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { UnitSystem.Metric, BmiClassification.Underweight, UNDERWIGHT_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Metric, BmiClassification.Normal, NORMAL_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Metric, BmiClassification.Overweight, OVERWEIGHT_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Metric, BmiClassification.Obesity, OBESITY_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Metric, BmiClassification.ExtremeObesity, EXTREMEOBESITY_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Imperial, BmiClassification.Underweight, UNDERWIGHT_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Imperial, BmiClassification.Normal, NORMAL_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Imperial, BmiClassification.Overweight, OVERWEIGHT_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Imperial, BmiClassification.Obesity, OBESITY_SUMMARY_TEXT };
            yield return new object[] { UnitSystem.Imperial, BmiClassification.ExtremeObesity, EXTREMEOBESITY_SUMMARY_TEXT };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
