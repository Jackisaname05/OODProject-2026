namespace OODProject_2026.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using OODProject_2026.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<OODProject_2026.Data.AppDbContext>
    {
        
        
        public Configuration()
        {
            
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OODProject_2026.Data.AppDbContext context)
        {
           
            try
            {

                //  This method will be called after migrating to the latest version.
                context.Characters.AddOrUpdate(c => c.Name,
                   new CharacterEntity
                   {
                       Name = "Spider-Man",
                       DebutYear = 1962,
                       Publisher = "Marvel Comics",
                       Description = "Peter Parker gained spider-like abilities after being bitten by a radioactive spider. After learning the lesson that great power comes with great responsibility, he became Spider-Man to protect New York City. His powers include superhuman strength, agility, wall-crawling and a spider-sense that warns him of danger. His stories often focus on balancing everyday life, relationships and responsibility while fighting powerful villains.",
                       ComicVineCharacterId = 1443,
                       CreatedAt = DateTime.Now,
                       UpdatedAt = DateTime.Now,
                       ComicVineSearchName = "Spider-Man"
                   },

                    new CharacterEntity
                    {
                        Name = "Batman",
                        DebutYear = 1939,
                        Publisher = "DC Comics",
                        Description = "Bruce Wayne witnessed the murder of his parents as a child and dedicated his life to fighting crime in Gotham City. Using his vast wealth, intelligence and years of training, he became Batman. While he has no superpowers, he relies on detective skills, martial arts mastery and advanced technology. His stories often explore crime, corruption and psychological conflict within Gotham.",
                        ComicVineCharacterId = 1699,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Batman"
                    },

                    new CharacterEntity
                    {
                        Name = "Superman",
                        DebutYear = 1938,
                        Publisher = "DC Comics",
                        Description = "Born on the planet Krypton as Kal-El, Superman was sent to Earth as a baby and raised as Clark Kent. Under Earth's yellow sun he developed incredible powers including super strength, flight, heat vision and invulnerability. As a symbol of hope and justice, he protects humanity from powerful threats while balancing his life as a journalist.",
                        ComicVineCharacterId = 1807,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Superman"
                    },

                    new CharacterEntity
                    {
                        Name = "Hulk",
                        DebutYear = 1962,
                        Publisher = "Marvel Comics",
                        Description = "Scientist Bruce Banner was exposed to gamma radiation which caused him to transform into the Hulk when experiencing intense emotion. The Hulk possesses immense strength, durability and regenerative abilities that increase with anger. Stories involving the Hulk often explore themes of inner conflict and the struggle to control overwhelming power..",
                        ComicVineCharacterId = 1457,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Hulk"
                    },

                    new CharacterEntity
                    {
                        Name = "Wonder Woman",
                        DebutYear = 1941,
                        Publisher = "DC Comics",
                        Description = "Princess Diana of Themyscira is an Amazon warrior trained in combat and diplomacy. Leaving her hidden island to protect the world, she became Wonder Woman. She possesses superhuman strength, speed and durability and wields magical weapons such as the Lasso of Truth and indestructible bracelets. Her stories often focus on justice, mythology and compassion.",
                        ComicVineCharacterId = 2048,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Wonder Woman"
                    },

                    new CharacterEntity
                    {
                        Name = "Wolverine",
                        DebutYear = 1974,
                        Publisher = "Marvel Comics",
                        Description = "Logan, known as Wolverine, is a mutant with powerful regenerative healing, heightened senses and retractable claws bonded with adamantium. Having lived through many wars and conflicts, he is a fierce but honorable fighter. His stories often explore identity, survival and the burden of a violent past.",
                        ComicVineCharacterId = 1456,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Wolverine"
                    },

                    new CharacterEntity
                    {
                        Name = "The Flash",
                        DebutYear = 1956,
                        Publisher = "DC Comics",
                        Description = "The Flash mantle has been carried by multiple speedsters in DC Comics, most notably Jay Garrick, Barry Allen, and Wally West. These heroes are connected by super-speed, heroic legacy, and the wider mythology of the Speed Force. Barry Allen is the Silver Age Flash, a forensic scientist whose transformation helped redefine the superhero genre and expand DC's stories involving time travel, alternate realities, and the science behind super-speed.",
                        ComicVineCharacterId = 1837,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "The Flash"
                    },

                    new CharacterEntity
                    {
                        Name = "Captain America",
                        DebutYear = 1941,
                        Publisher = "Marvel Comics",
                        Description = "During World War II, Steve Rogers volunteered for an experimental program that transformed him into the first super soldier. With enhanced strength, agility and leadership he became Captain America. Armed with his iconic shield, he represents courage and moral integrity while confronting both modern and historical threats.",
                        ComicVineCharacterId = 1442,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Captain America"
                    },

                    new CharacterEntity
                    {
                        Name = "Nightwing",
                        DebutYear = 1984,
                        Publisher = "DC Comics",
                        Description = "Dick Grayson was originally Batman's first partner, Robin. After growing into his own hero he became Nightwing, protecting the city of Blüdhaven. Known for his acrobatic skill, intelligence and leadership, Nightwing represents independence and growth while maintaining ties to the larger hero community.",
                        ComicVineCharacterId = 1692,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Nightwing"
                    },

                    new CharacterEntity
                    {
                        Name = "Moon Knight",
                        DebutYear = 1975,
                        Publisher = "Marvel Comics",
                        Description = "Marc Spector, a former soldier and mercenary, became the avatar of the Egyptian moon god Khonshu. As Moon Knight he fights crime using combat skills, advanced equipment and mystical influence. His stories often explore psychological conflict, identity and supernatural threats.",
                        ComicVineCharacterId = 1446,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Moon Knight"
                    },

                    new CharacterEntity
                    {
                        Name = "Invincible",
                        DebutYear = 2003,
                        Publisher = "Image Comics",
                        Description = "Mark Grayson is the son of Omni-Man, a powerful alien hero. As he develops similar abilities such as flight, strength and durability, he becomes the hero Invincible. His stories follow his journey learning to become a hero while dealing with difficult truths about power, responsibility and family.",
                        ComicVineCharacterId = 4005,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Invincible"
                    },

                    new CharacterEntity
                    {
                        Name = "Spawn",
                        DebutYear = 1992,
                        Publisher = "Image Comics",
                        Description = "Al Simmons was a soldier who was betrayed and killed, making a deal with dark forces to return to Earth. Reborn as Spawn, he possesses supernatural strength, necroplasmic powers and a living costume. His stories often involve dark themes, redemption and battles between heavenly and demonic forces..",
                        ComicVineCharacterId = 2250,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Spawn"
                    },

                    new CharacterEntity
                    {
                        Name = "Hellboy",
                        DebutYear = 1993,
                        Publisher = "Dark Horse Comics",
                        Description = "Summoned to Earth as a child and raised by humans, Hellboy works as a paranormal investigator combating supernatural threats. Despite his demonic origins he chooses to protect humanity. His stories blend folklore, mythology and dark adventure.",
                        ComicVineCharacterId = 2233,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Hellboy"
                    },

                    new CharacterEntity
                    {
                        Name = "Aquaman",
                        DebutYear = 1941,
                        Publisher = "DC Comics",
                        Description = "Arthur Curry is the heir to the underwater kingdom of Atlantis and acts as a bridge between the ocean and the surface world. With superhuman strength, aquatic adaptation and telepathic communication with sea life, he protects both realms. His stories often focus on leadership, politics and environmental conflict.",
                        ComicVineCharacterId = 1801,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Aquaman"
                    },

                    new CharacterEntity
                    {
                        Name = "Iron Fist",
                        DebutYear = 1974,
                        Publisher = "Marvel Comics",
                        Description = "Danny Rand gained mystical powers after training in the hidden city of K’un-Lun. By focusing his energy he can channel the legendary Iron Fist, delivering powerful strikes. His stories combine martial arts, mysticism and heroism in modern cities.",
                        ComicVineCharacterId = 1492,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Iron Fist"
                    },

                    new CharacterEntity
                    {
                        Name = "Luke Cage",
                        DebutYear = 1972,
                        Publisher = "Marvel Comics",
                        Description = "Carl Lucas gained superhuman strength and nearly unbreakable skin after an experimental prison procedure. As Luke Cage he protects his community while standing up to criminals and corruption. His stories often highlight street-level heroism and social justice.",
                        ComicVineCharacterId = 1445,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Luke Cage"
                    },

                    new CharacterEntity
                    {
                        Name = "Red Hood",
                        DebutYear = 2005,
                        Publisher = "DC Comics",
                        Description = "Jason Todd was once Batman’s partner before being presumed dead and later returning as the vigilante Red Hood. Unlike many heroes he uses more aggressive tactics and weapons in his fight against crime. His stories often explore redemption and moral conflict.",
                        ComicVineCharacterId = 6849,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Red Hood"
                    },

                    new CharacterEntity
                    {
                        Name = "Blue Beetle",
                        DebutYear = 1966,
                        Publisher = "DC Comics",
                        Description = "The Blue Beetle identity has been used by several heroes, including Dan Garrett, Ted Kord, and Jaime Reyes. Across those versions, the mantle is associated with innovation, heroism, and evolving comic book eras, from pulp-inspired adventuring to more modern science fiction storytelling. Ted Kord is the second Blue Beetle and stands out for relying on intelligence, athletic skill, gadgets, and inventions rather than superpowers, making him especially known for his partnership with Booster Gold and his role in Justice League International stories.",
                        ComicVineCharacterId = 2054,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Blue Beetle"
                    },

                    new CharacterEntity
                    {
                        Name = "Booster Gold",
                        DebutYear = 1986,
                        Publisher = "DC Comics",
                        Description = "Michael Carter traveled back in time from the future using advanced technology to become a hero in the present. As Booster Gold he uses future equipment and support from his robotic companion Skeets. His stories often combine humor, heroism and redemption.",
                        ComicVineCharacterId = 1786,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Booster Gold"
                    },

                    new CharacterEntity
                    {
                        Name = "Thor",
                        DebutYear = 1962,
                        Publisher = "Marvel Comics",
                        Description = "Thor is the Asgardian god of thunder who protects both Earth and the realms beyond. Wielding the enchanted hammer Mjolnir, he commands lightning, immense strength and durability. His stories often explore mythology, cosmic battles and heroism.",
                        ComicVineCharacterId = 1460,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Thor"
                    },

                    new CharacterEntity
                    {
                        Name = "Shazam",
                        DebutYear = 1940,
                        Publisher = "DC Comics",
                        Description = "Young Billy Batson can transform into the hero Shazam by speaking a magical word that grants him the powers of legendary figures. With incredible strength, speed and magical abilities, he protects the innocent while learning what it means to be a hero.",
                        ComicVineCharacterId = 1799,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Shazam"
                    },

                    new CharacterEntity
                    {
                        Name = "Ant-Man",
                        DebutYear = 1962,
                        Publisher = "Marvel Comics",
                        Description = "The Ant-Man identity has been used by multiple heroes in Marvel Comics, including Hank Pym, Scott Lang, and Eric O'Grady. Across these versions, the mantle is defined by the use of Pym Particles, which allow the user to change size while retaining strength, as well as communication with insects. Hank Pym is the original Ant-Man, a brilliant but often troubled scientist whose work led to many identities including Ant-Man, Giant-Man, and Yellowjacket, and who played a key role in founding the Avengers.",
                        ComicVineCharacterId = 1444,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Ant-Man"
                    },

                    new CharacterEntity
                    {
                        Name = "Iron Man",
                        DebutYear = 1963,
                        Publisher = "Marvel Comics",
                        Description = "Genius inventor Tony Stark created a powerful armored suit to escape captivity and later refined it to become Iron Man. His suits grant flight, advanced weapons and technological abilities. His stories explore innovation, responsibility and the cost of heroism.",
                        ComicVineCharacterId = 1455,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    },

                    new CharacterEntity
                    {
                        Name = "Ghost Rider",
                        DebutYear = 1972,
                        Publisher = "Marvel Comics",
                        Description = "The Ghost Rider mantle has been held by several individuals, including Johnny Blaze, Danny Ketch, Robbie Reyes, and others. Each version is tied to a supernatural Spirit of Vengeance, granting abilities such as hellfire manipulation and the power to punish the guilty. Johnny Blaze is the original modern Ghost Rider, a stunt motorcyclist who made a deal that bound him to a demonic entity, leading to stories centered on redemption, vengeance, and the supernatural.",
                        ComicVineCharacterId = 1462,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Ghost Rider"
                    },

                    new CharacterEntity
                    {
                        Name = "Green Lantern",
                        DebutYear = 1940,
                        Publisher = "DC Comics",
                        Description = "The Green Lantern mantle is shared by multiple heroes connected to the Green Lantern Corps, including Hal Jordan, John Stewart, Guy Gardner, and Kyle Rayner. Together they represent willpower, responsibility, and DC's cosmic side, with each Lantern bringing a different personality and style to the role. Hal Jordan is one of the best-known human Green Lanterns, a fearless test pilot whose stories often focus on courage, redemption, and major intergalactic threats.",
                        ComicVineCharacterId = 1809,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Green Lantern"
                    },

                    new CharacterEntity
                    {
                        Name = "Doctor Strange",
                        DebutYear = 1963,
                        Publisher = "Marvel Comics",
                        Description = "Dr. Stephen Strange was once a brilliant but arrogant surgeon until an accident led him to study the mystic arts. Becoming the Sorcerer Supreme, he protects reality from magical and dimensional threats using powerful spells and artifacts.",
                        ComicVineCharacterId = 1453,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Doctor Strange"
                    },

                    new CharacterEntity
                    {
                        Name = "Black Panther",
                        DebutYear = 1966,
                        Publisher = "Marvel Comics",
                        Description = "T’Challa is the king of Wakanda, a technologically advanced African nation. As Black Panther he possesses enhanced strength and agility granted by a sacred herb and uses advanced Wakandan technology to defend his people and the world.",
                        ComicVineCharacterId = 1477,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Black Panther"
                    },

                    new CharacterEntity
                    {
                        Name = "Green Arrow",
                        DebutYear = 1941,
                        Publisher = "DC Comics",
                        Description = "Oliver Queen is a skilled archer who fights crime using precision, strategy and a wide variety of trick arrows. Often operating at a street-level, his stories explore justice, politics and social issues.",
                        ComicVineCharacterId = 5936,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        ComicVineSearchName = "Green Arrow"
                    }


                );
            }
            //
            catch (DbEntityValidationException ex)
            {
                // Log the validation errors for debugging
                foreach (var eve in ex.EntityValidationErrors)
                {
                    //
                    System.Diagnostics.Debug.WriteLine("Entity: " + eve.Entry.Entity.GetType().Name);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("  Property: " + ve.PropertyName + " Error: " + ve.ErrorMessage);
                    }
                }
                throw;
            }
            
        }
    }
}
