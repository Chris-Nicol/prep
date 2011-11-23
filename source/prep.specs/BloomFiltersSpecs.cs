using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using prep.collections;

namespace prep.specs
{
    [Subject(typeof(BloomFilter))]
    public class BloomFiltersSpecs
    {
        public abstract class bloomfilter_concern : Observes<BloomFilter>
        {
            protected static Array[] blooms;

            Establish c = () =>
            {
                blooms = new Array[0];
                depends.on(blooms);
            };
        };

        public class should_return_an_array_with_two_byte_arrays : bloomfilter_concern
        {
            static int number_of_byte_arrays;

            Establish c = () =>
              blooms = BloomFilter.CreateWordArray(2);

            Because b = () =>
              number_of_byte_arrays = blooms.Length;

            It should_return_the_number_of_all_movies_in_the_library = () =>
            {
                number_of_byte_arrays.ShouldEqual(2);
            };
        }

    }

    public class BloomFilter
    {

        public static Array[] CreateWordArray(int numberOfWords)
        {
            var result = new Array[numberOfWords];

            for (int i = 0; i < numberOfWords; i++)
            {
                var cryptoProvider = new MD5CryptoServiceProvider();
                var bytes = System.Text.Encoding.UTF8.GetBytes("word" + 1);
                bytes = cryptoProvider.ComputeHash(bytes);

                result[i] = bytes;
            }

            return result;
        }

    }
}