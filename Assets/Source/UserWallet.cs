using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source
{
    internal class UserWallet : MonoBehaviour
    {
        public int Value { get; private set; }

        public void AddCoin(int value = 1)
        {
            Value++;
        }
    }
}
