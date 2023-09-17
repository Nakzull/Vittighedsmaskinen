using Jokes.Models;

namespace Jokes.Services
{
    public class JokeService
    {
        private List<Joke> jokes;
        Random rng = new Random();

        public JokeService()
        {
            jokes = new List<Joke>
            {
                new Joke { Text = "Hvorfor skulle skyen i skole?\r\n– Fordi den skulle lære at regne",
                Category = "Dad",
                Language = "Dansk"
            },
            new Joke { Text = "Hvorfor er det at fisk er så grimme?\r\n– Det er jo selvfølgelig fordi at de er van(d)skabte",
                Category = "Dad",
                Language = "Dansk"
            },
            new Joke { Text = "Hvad er det mindst talte sprog i verden? \r\n– Tegnsprog",
                Category = "Dad",
                Language = "Dansk"
            },
            new Joke { Text = "Hvad sagde den ene cykel til den anden?\r\n– Styr dig!",
                Category = "Dad",
                Language = "Dansk"
            },
            new Joke { Text = "Hvad fik den lille kannibaldreng, som kom for sent til aftensmaden\r\n– En kold skulder",
                Category = "Dad",
                Language = "Dansk"
            },
            new Joke { Text = "Chuck Norris har engang spillet russisk roulette med en fuldt ladt pistol \r\n– Og vundet!",
                Category = "Chuck Norris",
                Language = "Dansk"
            },
            new Joke { Text = "Da Gud sagde “Lad der blive lys!”, lød Chuck Norris stemme fra jorden\r\n– “Sig be`om!”",
                Category = "Chuck Norris",
                Language = "Dansk"
            },
            new Joke { Text = "Hvis du skriver Chuck Norris i Word Feud, så vinder du. Forevigt!",
                Category = "Chuck Norris",
                Language = "Dansk"
            },
            new Joke { Text = "Chuck Norris har talt til uendeligt – To gange endda.",
                Category = "Chuck Norris",
                Language = "Dansk"
            },
            new Joke { Text = "Chuck Norris’ tårer kan helbrede kræft. Ærgerligt han aldrig har grædt",
                Category = "Chuck Norris",
                Language = "Dansk"
            },
            new Joke { Text = "Hvorfor må man ikke have bøsse med op i et højhus?\r\n– Tænk hvis de nu springer ud",
                Category = "Inappropriate",
                Language = "Dansk"
            },
            new Joke { Text = "Hvad kalder man en ged der dyrker sikker sex?\r\n– En gummiged",
                Category = "Inappropriate",
                Language = "Dansk"
            },
            new Joke { Text = "Hvorfor minder en kvinde om et kondom?\r\n– De bruger begge mere tid i din pung, end på din pik",
                Category = "Inappropriate",
                Language = "Dansk"
            },
            new Joke { Text = "Alle børnene havde respekt for læreren.\r\n– Undtagen Max, han stak hende ned med en saks",
                Category = "Inappropriate",
                Language = "Dansk"
            },
            new Joke { Text = "Folk er blevet ret godt sure på BonBon, over deres nye tiltag af slik: Perker-hjerner!\r\nHvordan kan man tillade sig at sælge en tom pose der lugter af hvidløg!",
                Category = "Inappropriate",
                Language = "Dansk"
            },
            new Joke { Text = "I'm afraid for the calendar. Its days are numbered.",
                Category = "Dad",
                Language = "English"
            },
            new Joke { Text = "My wife said I should do lunges to stay in shape. That would be a big step forward.",
                Category = "Dad",
                Language = "English"
            },
            new Joke { Text = "Why do fathers take an extra pair of socks when they go golfing? In case they get a hole in one!",
                Category = "Dad",
                Language = "English"
            },
            new Joke { Text = "Singing in the shower is fun until you get soap in your mouth. Then it's a soap opera.",
                Category = "Dad",
                Language = "English"
            },
            new Joke { Text = "What do a tick and the Eiffel Tower have in common? They're both Paris sites.",
                Category = "Dad",
                Language = "English"
            },
            new Joke { Text = "Chuck Norris doesn't read books. He stares them down until he gets the information he wants.",
                Category = "Chuck Norris",
                Language = "English"
            },
            new Joke { Text = "Time waits for no man. Unless that man is Chuck Norris.",
                Category = "Chuck Norris",
                Language = "English"
            },
            new Joke { Text = "If you spell Chuck Norris in Scrabble, you win. Forever.",
                Category = "Chuck Norris",
                Language = "English"
            },
            new Joke { Text = "Chuck Norris breathes air ... five times a day.",
                Category = "Chuck Norris",
                Language = "English"
            },
            new Joke { Text = "In the Beginning there was nothing ... then Chuck Norris roundhouse kicked nothing and told it to get a job.",
                Category = "Chuck Norris",
                Language = "English"
            },
            new Joke { Text = "What did the toaster say to the slice of bread? \"I want you inside me.\"",
                Category = "Inappropriate",
                Language = "English"
            },
            new Joke { Text = "\"Give it to me! Give it to me!\" she yelled. \"I'm so wet, give it to me now!\" She could scream all she wanted, but I was keeping the umbrella.",
                Category = "Inappropriate",
                Language = "English"
            },
            new Joke { Text = "Two men broke into a drugstore and stole all the Viagra. The police put out an alert to be on the lookout for the two hardened criminals.",
                Category = "Inappropriate",
                Language = "English"
            },
            new Joke { Text = "They say that during sex you burn off as many calories as running eight miles. Who the hell runs eight miles in 30 seconds?",
                Category = "Inappropriate",
                Language = "English"
            },
            new Joke { Text = "Why do walruses love a Tupperware party? They're always on the lookout for a tight seal.",
                Category = "Inappropriate",
                Language = "English"
            }
            };
        }

        public List<Joke> GetJokes()
        {
            return jokes;
        }

        public List<string> GetCategories()
        {
            List<string> categories = new List<string>()
            {
            "Dad",
            "Chuck Norris",
            "Inappropriate"
            };
            return categories;
        }

        public Joke GetAJoke(List<Joke> usedJokes, string category, string[] languages)
        {
            foreach (Joke joke1 in usedJokes)
            {
                jokes.RemoveAll(x => x.Text == joke1.Text);
            }

            if (languages.Any(lang => lang.Trim().StartsWith("da")))
            {
                jokes.RemoveAll(x => x.Language != "Dansk");
            }
            else if (languages.Any(lang => lang.Trim().StartsWith("en")))
            {
                jokes.RemoveAll(x => x.Language != "English");
            }

            if (category == "Dad")
            {
                jokes.RemoveAll(x => x.Category != category);
            }
            else if (category == "Chuck Norris")
            {
                jokes.RemoveAll(x => x.Category != category);
            }
            else if (category == "Inappropriate")
            {
                jokes.RemoveAll(x => x.Category != category);
            }
            int jokeNumber = rng.Next(0, jokes.Count);
            Joke joke = new Joke();
            joke = jokes[jokeNumber];
            return joke;
        }
    }
}

