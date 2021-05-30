from scipy.spatial import Delaunay
import matplotlib.pyplot as plt
import numpy as np

points = np.array([[0, 4], [2, 1.1], [1, 2], [4,0], [1.5, 3.85], [1.76, 5] ])
#plt.plot(points)
#plt.show

tri = Delaunay(points)

plt.triplot(points[:,0], points[:,1], tri.simplices.copy())

plt.plot(points[:,0], points[:,1], 'o')

plt.show()