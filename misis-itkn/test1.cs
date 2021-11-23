using System;

namespace check1 {
    public class Program {
		public static void Main(string[] args) {
			int[] a = new int[10] {-10000, -22, -3, 4, 5, -6, 100000, 8, 15, 10},
				b = new int[8];
	
		    int amax = a[0], imax = 0, amin = a[0], imin = 0, k = 0;
	
		    for (int i = 1; i < 10; i++) {
				if (a[i] > amax) {
					amax = a[i];
					imax = i;
				}
				
				if (a[i] < amin) {
					amin = a[i];
					imin = i;
				}
			}
			
			if(imax < imin) {
				int swap = amax;
				amax = amin;
				amin = swap;
				swap = imax;
				imax = imin;
				imin = swap;
			}
			
			for (int i = imin + 1; i < imax; i++) {
				if (a[i] < 0) {
					b[k] = a[i];
					k++;
				}
			}
			
			for (int i = 0; i < k; i++) {
				Console.Write(b[i]);
				Console.Write(" ");
			}
		}
	}
}