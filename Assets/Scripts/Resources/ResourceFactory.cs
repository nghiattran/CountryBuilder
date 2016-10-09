using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Resources {
		[SerializeField] public List<AgricultureWrapper> agrResources;
		[SerializeField] public List<IndustrialWrapper> indResources;
		[SerializeField] public Dictionary<string, AgricultureWrapper> agrResourceDict;
		[SerializeField] public Dictionary<string, IndustrialWrapper> indResourceDict;

		public Resources(List<AgricultureResource> _agrResources, 
			List<IndustrialResource> _indResources) 
		{
			agrResources = new List<AgricultureWrapper>();
			indResources = new List<IndustrialWrapper>();

			agrResourceDict = new Dictionary<string, AgricultureWrapper>();
			indResourceDict = new Dictionary<string, IndustrialWrapper>();

			SpawnResources(agrResources, _agrResources);
			SpawnResources(indResources, _indResources);
		}

		public void Start() {
			agrResourceDict = new Dictionary<string, AgricultureWrapper>();
			indResourceDict = new Dictionary<string, IndustrialWrapper>();
			for (int i = 0; i < agrResources.Count; i++) {
				agrResourceDict.Add(agrResources[i].GetName(), agrResources[i]);
			}

			for (int i = 0; i < indResources.Count; i++) {
				indResourceDict.Add(indResources[i].GetName(), indResources[i]);
			}
		}

		public AgricultureWrapper GetAgricultureResource(string name) {
			if (agrResourceDict != null && agrResourceDict.ContainsKey(name)) {
				return agrResourceDict[name];
			}
			return null;
		}

		void SpawnResources<T, T2> (List<T> wrapper, List<T2> resources) where T:class 
		{
			for (int i = 0; i < resources.Count; i++) {
				T instance = Activator.CreateInstance(typeof(T), new object[] {resources[i]}) as T;
				wrapper.Add(instance);
			}
		}
	}

	public class ResourceFactory {
		static private ResourceFactory instance;
		List<AgricultureResource> agrResources;
		List<IndustrialResource> indResources;

		ResourceFactory() {
			agrResources = new List<AgricultureResource>();
			indResources = new List<IndustrialResource>();

			agrResources.Add(new Food());
		}

		static public ResourceFactory GetInstance() {
			if (instance == null) {
				instance = new ResourceFactory();
			}
			return instance;
		}

		public Resources CloneResources() {
			return new Resources(agrResources, indResources);
		}

		public List<AgricultureResource> GetAgricultureResources() {
			return agrResources;
		}

		public List<IndustrialResource> GetIndustrialResources() {
			return indResources;
		}
	}
}