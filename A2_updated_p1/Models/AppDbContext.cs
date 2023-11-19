using Microsoft.EntityFrameworkCore;

namespace A2_updated_p1.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<FAQ> FAQs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // One-to-Many relationship between Category and Topic
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Topics)
                .WithOne(t => t.Category)
                .HasForeignKey(t => t.CategoryId)
                .OnDelete(DeleteBehavior.Restrict); 

            // One-to-Many relationship between Topic and FAQ
            modelBuilder.Entity<Topic>()
                .HasMany(t => t.FAQs)
                .WithOne(f => f.Topic)
                .HasForeignKey(f => f.TopicId)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed data for Categories, Topics, and FAQs


            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "coding", Name = "Coding" },
                new Category { CategoryId = "history", Name = "History" },
                new Category { CategoryId = "gadgets", Name = "Gadgets" },
                new Category { CategoryId = "science", Name = "Science" },
                new Category { CategoryId = "travel", Name = "Travel" },
                new Category { CategoryId = "movies", Name = "Movies" },
                new Category { CategoryId = "health", Name = "Health" },
                new Category { CategoryId = "sports", Name = "Sports" },
                new Category { CategoryId = "music", Name = "Music" },
                new Category { CategoryId = "food", Name = "Food" }
                
            );

            modelBuilder.Entity<Topic>().HasData(
                new Topic { TopicId = "java", Name = "Java", CategoryId = "coding" },
                new Topic { TopicId = "python", Name = "Python", CategoryId = "coding" },
                new Topic { TopicId = "history-events", Name = "Historical Events", CategoryId = "history" },
                new Topic { TopicId = "smartphones", Name = "Smartphones", CategoryId = "gadgets" },
                new Topic { TopicId = "space", Name = "Space Exploration", CategoryId = "science" },
                new Topic { TopicId = "europe-travel", Name = "Europe Travel", CategoryId = "travel" },
                new Topic { TopicId = "action-movies", Name = "Action Movies", CategoryId = "movies" },
                new Topic { TopicId = "mental-health", Name = "Mental Health", CategoryId = "health" },
                new Topic { TopicId = "football", Name = "Football", CategoryId = "sports" },
                new Topic { TopicId = "rock-music", Name = "Rock Music", CategoryId = "music" }
                
            );

            modelBuilder.Entity<FAQ>().HasData(
    new FAQ { FAQId = 1, Question = "What is Java?", Answer = "Java is a programming language...", TopicId = "java", CategoryId = "coding" },
    new FAQ { FAQId = 2, Question = "Tell me about Python.", Answer = "Python is a versatile programming language...", TopicId = "python", CategoryId = "coding" },
    new FAQ { FAQId = 3, Question = "What are historical events?", Answer = "Historical events are significant occurrences...", TopicId = "history-events", CategoryId = "history" },
    new FAQ { FAQId = 4, Question = "How do smartphones work?", Answer = "Smartphones are handheld devices that combine...", TopicId = "smartphones", CategoryId = "gadgets" },
    new FAQ { FAQId = 5, Question = "What is space exploration?", Answer = "Space exploration involves the discovery and exploration...", TopicId = "space", CategoryId = "science" },
    new FAQ { FAQId = 6, Question = "Best places to visit in Europe?", Answer = "Europe offers a variety of beautiful destinations including...", TopicId = "europe-travel", CategoryId = "travel" },
    new FAQ { FAQId = 7, Question = "Must-watch action movies?", Answer = "Action movies are known for their thrilling...", TopicId = "action-movies", CategoryId = "movies" },
    new FAQ { FAQId = 8, Question = "How to maintain mental health?", Answer = "Maintaining mental health involves practices like...", TopicId = "mental-health", CategoryId = "health" },
    new FAQ { FAQId = 9, Question = "Football rules and regulations.", Answer = "Football is a popular sport played between two teams...", TopicId = "football", CategoryId = "sports" },
    new FAQ { FAQId = 10, Question = "Influential rock music bands.", Answer = "Rock music has been shaped by iconic bands like...", TopicId = "rock-music", CategoryId = "music" }
   
);




        }
    }
}
