using System;
using System.Collections;
using _Scripts.Utilities.StatModifiers.Demo.StatModifiers;
using CodiceApp.EventTracking.Plastic;
using UnityEngine;

namespace _Scripts.Utilities.StatModifiers.Demo {
    public class VaultDweller : MonoBehaviour {
        public FalloutStats stats;
        
        private void Awake() {
            // Here we instantiate the FalloutStats class and add a BasicStatModifier to it.
            // In an actual implementation, the base stats would be stored in a ScriptableObject and loaded from a file.
            stats = new FalloutStats(
                                     new FalloutStatsMediator(),
                                     ScriptableObject.CreateInstance<FalloutBaseStats>()
                                    );
            
            // For demonstration purposes, here we add a BasicStatModifier to the mediator.
            // For BasicStatModifier, we pass in the stat, duration, and the function that handles the operation.
            AddModifier(new BasicStatModifier(FalloutStatType.Strength, 5, i => i + 1));
            StartCoroutine(PrintEverySecond());
        }

        private void Update() {
            // Since the mediator is just a class, we need to manually call update and pass in the deltaTime.
            stats.Mediator.Update(Time.deltaTime);
        }

        private IEnumerator PrintEverySecond() {
            while (true) {
                yield return new WaitForSeconds(1);
                Debug.Log($"Strength: {stats.Strength}");
                Debug.Log($"Perception: {stats.Perception}");
                Debug.Log($"Endurance: {stats.Endurance}");
                Debug.Log($"Charisma: {stats.Charisma}");
                Debug.Log($"Intelligence: {stats.Intelligence}");
                Debug.Log($"Agility: {stats.Agility}");
                Debug.Log($"Luck: {stats.Luck}");
            }
            // ReSharper disable once IteratorNeverReturns
        }
        
        /// <summary>
        /// Adds a stat modifier to the vault dweller
        /// </summary>
        public void AddModifier(FalloutStatModifier modifier) {
            stats.Mediator.AddModifier(modifier);
        }
    }
}