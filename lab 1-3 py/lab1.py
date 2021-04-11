from tkinter import *

coords = []

def drawLine(x1,y1,x2,y2):
    # алгоритм цда

    k = (y2 - y1)/(x2 - x1)
    y = y1

    for x in range(x1,x2):
        img.put("#000000", (round(x), round(y)))
        y += k


def clicked(event):
    global coords
    ix, iy = round(event.x), round(event.y)
    coords.append((ix, iy))

    if len(coords) == 2:
        drawLine(coords[0][0], coords[0][1], coords[1][0], coords[1][1])
        # drawLine(2,5,5,1)
        print(coords[0][0], coords[0][1], coords[1][0], coords[1][1])

WIDTH, HEIGHT = 500, 500
root = Tk()
canvas = Canvas(root, width=WIDTH, height=HEIGHT)
canvas.pack()
img = PhotoImage(width=WIDTH, height=HEIGHT)
canvas.create_image((WIDTH/2,HEIGHT/2), image=img, state="normal")
#img.put("#000000", (100,100))
root.bind('<Button-1>', clicked)
mainloop()
