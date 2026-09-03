using SearchAutocompleteSystem.Strategy;
using System;
using System.Collections.Generic;
using System.Text;

namespace SearchAutocompleteSystem.Builder
{
    internal class AutocompleteSystemBuilder
    {
        IRankingStrategy rankingStrategy = new FrequencyBasedRanking();
        int maxSuggestions = 10;
        public AutocompleteSystemBuilder WithRankingStrategy(IRankingStrategy rankingStrategy)
        {
            this.rankingStrategy = rankingStrategy;
            return this;
        }
        public AutocompleteSystemBuilder WithMaxSuggestions(int maxSuggestions) { 
            this.maxSuggestions = maxSuggestions;
            return this;
        }
    
        public AutocompleteSystem Build()
        {
            return new(rankingStrategy, maxSuggestions);
        }
    }
}
