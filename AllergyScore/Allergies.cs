using System;
using System.Collections.Generic;

namespace AllergyScore
{
    /// <summary>
    /// Encapsulate the information about allergy test score and its analysis.
    /// </summary>
    public class Allergies
    {
        private readonly int testScore;

        /// <summary>
        /// Initializes a new instance of the <see cref="Allergies"/> class with test score.
        /// </summary>
        /// <param name="score">The allergy test score.</param>
        /// <exception cref="ArgumentException">Thrown when score is less than zero.</exception>
        public Allergies(int score)
        {
            if (score < 0)
            {
                throw new ArgumentException($"Size of matrix '{score}' cannot be less than zero.");
            }

            this.testScore = score;
        }

        /// <summary>
        /// Determines on base on the allergy test score for the given person, whether or not they're allergic to a given allergen(s).
        /// </summary>
        /// <param name="allergens">Allergens.</param>
        /// <returns>true if there is an allergy to this allergen, false otherwise.</returns>
        public bool IsAllergicTo(Allergens allergens)
        {
            Allergens[] personAllergens = this.AllergensList();
            for (int i = 0; i < personAllergens.Length; i++)
            {
                if (allergens.HasFlag(personAllergens[i]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Determines the full list of allergies of the person with given allergy test score.
        /// </summary>
        /// <returns>Full list of allergies of the person with given allergy test score.</returns>
        public Allergens[] AllergensList()
        {
            List<Allergens> personAllergens = new List<Allergens>();
            for (int i = 1; i <= 128; i *= 2)
            {
                if (((Allergens)this.testScore).HasFlag((Allergens)i))
                {
                    personAllergens.Add((Allergens)i);
                }
            }

            return personAllergens.ToArray();
        }
    }
}
