using System;

namespace ContractorCore.DBModels
{
    public class oBaseObj : IDisposable
    {
        #region implementacja IDisposable
        /// <summary>
        /// Finalizer, wywołuje Dispose,
        /// <strong>nie nalezy na nim polegać!</strong>.
        /// </summary>
        ~oBaseObj()
        {
            Dispose(false);
        }

        /// <summary>
        /// Zwalnia używane zasoby. Wyrejestrowuje finalizer,
        /// by niepotrzebnie nie opóźniać zwalniania pamięci.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Zwalnia używane zasoby.
        /// </summary>
        /// <param name="disposing">czy mamy czas na dokładne sprzątanie?</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    //tutaj trafia to, co _powinniśmy_ posprzątać
                }
            }
            disposed = true;
        }

        /// <summary>Aby tylko raz zwalniac zasoby.
        /// (Dispose może zostać wywołane wielokrotnie.)</summary>
        protected bool disposed = false;

        #endregion

        #region MyRegion
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        #endregion
    }
}
