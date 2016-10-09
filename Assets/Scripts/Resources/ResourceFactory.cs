using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NghiaTTran.CountryBuilder {
	[System.Serializable]
	public class Resources {
		[SerializeField] public List<AgricultureWrapper> agrResources;
		[SerializeField] public List<IndustrialWrapper> indResources;

		public Resources(List<AgricultureResource> _agrResources, 
			List<IndustrialResource> _indResources) 
		{
			agrResources = new List<AgricultureWrapper>();
			indResources = new List<IndustrialWrapper>();

			SpawnResources(agrResources, _agrResources);
			SpawnResources(indResources, _indResources);
		}

		void SpawnResources<T, T2> (List<T> wrapper, List<T2> resources) where T:class {
			for (int i = 0; i < resources.Count; i++) {
				wrapper.Add(Activator.CreateInstance(typeof(T), new object[] {resources[i]}) as T);
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