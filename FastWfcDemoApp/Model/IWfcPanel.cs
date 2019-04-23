using System.Threading.Tasks;

namespace FastWfcDemoApp.Model
{
    /// <summary>
    /// Interface for Views.
    /// </summary>
    public interface IWfcPanel
    {
        /// <summary>
        /// Runs the WFC algorithm.
        /// </summary>
        Task RunWfc();
    }
}
