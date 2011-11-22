using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using prep.bloomfilters;
using prep.collections;

namespace prep.specs
{
    [Subject(typeof(MovieLibrary))]
    public class KataBloomFiltersSpecs
    {
        public abstract class bloomfilter_concern : Observes<BloomFilter>
        {
            protected static byte[] Bitmap;

            Establish c = () =>
            {
                Bitmap = new BloomFilter().GetArray();
                depends.on(Bitmap);
            };
        };

        public class should_return_an_array_of_bits : bloomfilter_concern
        {
            static int number_of_hashes;

            Establish c = () =>
              sut.GenerateHashValues("word another");

            Because b = () =>
              number_of_hashes = sut.GetArray().Count();

            It should_return_the_number_of_all_movies_in_the_library = () =>
            {
                number_of_hashes.ShouldBeGreaterThan(0);
            };
        }
    }
}
