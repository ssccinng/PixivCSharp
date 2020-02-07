using System;
using System.Net.Http;
using PixivCSharp;

namespace PixivCSharp.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Pixiv client = new Pixiv();
            Pixiv.WalkthoughIllusts();
        }
    }
}