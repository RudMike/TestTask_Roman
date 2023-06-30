//-----------------------------------------------------------------------
// <copyright file="DbContextFactory.cs" company="RudMike">
//     Author: Mike Rudnikov
//     Copyright (c) RudMike. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using TestTask_Roman.Data.Contexts;

namespace TestTask_Roman.Infrastructure
{
    /// <summary>
    /// A factory for creating and managing instances of <see cref="MedicalDbContext"/>.
    /// </summary>
    public class DbContextFactory : IDisposable
    {
        private readonly Func<MedicalDbContext> dbContextFactory;
        private bool disposedValue;
        private MedicalDbContext context = null!;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory"/> class with the specified factory function for creating instances of <see cref="MedicalDbContext"/>.
        /// </summary>
        /// <param name="dbContextFactory">The factory function for creating instances of <see cref="MedicalDbContext"/>.</param>
        public DbContextFactory(Func<MedicalDbContext> dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        /// <summary>
        /// Gets the current instance of <see cref="MedicalDbContext"/> managed by the factory.
        /// If no instance currently exists, a new instance is created using the factory function provided during initialization.
        /// </summary>
        public MedicalDbContext Context
        {
            get => this.context ??= this.dbContextFactory.Invoke();
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases all resources used by the <see cref="DbContextFactory"/> object.
        /// </summary>
        /// <param name="disposing">True if disposing managed resources; otherwise, false.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    this.context?.Dispose();
                }

                this.disposedValue = true;
            }
        }
    }
}
