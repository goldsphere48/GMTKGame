using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GMTKGame
{
    internal class SideProjectionMaterialsStore : MonoBehaviour
    {
        [SerializeField] private List<Material> _materials;
        private List<SideProjection> _sideProjections;

        private void Awake()
        {
            _sideProjections = GetComponentsInChildren<SideProjection>().ToList();
        }

        public void SetupProjections()
        {
            foreach (var sideProjection in _sideProjections)
            {
                sideProjection.ChangeMaterial();
            }
        }

        public Material GetMaterial(int number)
        {
            return _materials[number - 1];
        }
    }
}
