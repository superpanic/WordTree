using System;
using System.IO;
using System.Collections.Generic;

namespace WordTree {
	class Program {

		static readonly string wordFile = @"words.txt";

		static void Main(string[] args) {

			long milliseconds;

			bool isRoot = true;
			WordNode rootNode = new WordNode(isRoot);

			if (File.Exists(wordFile)) {
				using (StreamReader file = new StreamReader(wordFile)) {
					int counter = 0;
					string ln;

					milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

					while ( (ln = file.ReadLine()) != null ) {
						rootNode.AddWord( ln );
						counter++;
					}

					milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - milliseconds;

					file.Close();
					Console.WriteLine($"Read {counter} words from text file in {milliseconds} milliseconds.");
				}
			}

			List<string> wordList;
			wordList = new List<string> {
				"banana",
				"calming",
				"astronomy",
				"astrology",
				"astrologx",
				"bandana",
				"bandanaz",
				"calling",
				"hidden",
				"hxdden",
				"asthma",
				"astronaut",
				"axtronaut",
				"ape",
				"coconut",
				"police",
				"baker",
				"home",
				"computercomputer",
				"computer",
				"a",
				"i",
				"aha",
				"haha",
				"bah",
				"baha"
			};
			
			List<bool> foundWord;
			foundWord = new List<bool>();

			milliseconds = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
			for (int i = 0; i < wordList.Count; i++) {
				if (rootNode.ReadWord(wordList[i]) > 0) foundWord.Add(true);
				else foundWord.Add(false);
			}
			milliseconds = (DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond) - milliseconds;

			Console.WriteLine($"Searched {wordList.Count} words in {milliseconds} milliseconds:");
			Console.WriteLine("  {0,-20} {1,-10}", "WORD", "FOUND");
			for (int i = 0; i < wordList.Count; i++) {
				Console.WriteLine("  {0,-20} {1,-10}", wordList[i], foundWord[i]);
//				Console.WriteLine($"{wordList[i]}........{foundWord[i]}");
			}


		}

		static void SearchString(WordNode rootNode, string s) {
			int r = rootNode.ReadWord(s);
			if (r > 0) {
				Console.WriteLine("word: " + s + " found! (" + r + " chars long)");
			} else {
				Console.WriteLine("word: " + s + " not found!");
			}
		}

	}
}



/*
static void Main(string[] args) {

	List<string> wordList;
			
	wordList = new List<string> {
		"banana",
		"calming",
		"astronomy",
		"astrology",
		"bandana",
		"calling",
		"hidden",
		"asthma",
		"astronaut",
		"ape"
	};
	wordList.Sort();

	bool isRoot = true;
	WordNode rootNode = new WordNode(isRoot);
	for (int i = 0; i < wordList.Count; i++) {
		rootNode.AddWord(wordList[i]);
	}

	SearchString(rootNode, "ape");
	SearchString(rootNode, "banana");
	SearchString(rootNode, "coconut");

}
*/