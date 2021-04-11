from tkinter import *

coords = []

def drawCircle(x1,y1,R):
    x = 0
    y = R
    delta = 2 - 2 * R
    error = 0
    while y >= 0:
        img.put("#000000",(x1 + x, y1 + y))
        img.put("#000000",(x1 + x, y1 - y))
        img.put("#000000",(x1 - x, y1 + y))
        img.put("#000000",(x1 - x, y1 - y))
        error = 2 * (delta + y) - 1
        if delta < 0 and error <= 0:
            x += 1
            delta += 2*x+1
            continue
        if delta > 0 and error > 0:
            y -= 1
            delta -= 2 * y + 1
            continue
        x += 1
        delta += 2 * (x - y)
        y -= 1

def clicked(event):
    global coords
    ix, iy = round(event.x), round(event.y)
    coords.append((ix, iy))

    if len(coords) == 1:
        drawCircle(coords[0][0], coords[0][1], 100)
        print(coords[0][0], coords[0][1])

WIDTH, HEIGHT = 500, 500
root = Tk()
canvas = Canvas(root, width=WIDTH, height=HEIGHT)
canvas.pack()
img = PhotoImage(width=WIDTH, height=HEIGHT)
canvas.create_image((WIDTH/2,HEIGHT/2), image=img, state="normal")
#img.put("#000000", (100,100))
root.bind('<Button-1>', clicked)
mainloop()