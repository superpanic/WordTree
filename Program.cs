using System;
using System.Collections.Generic;

namespace WordTree {
	class Program {
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
				"ape",
				"monkey"
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
