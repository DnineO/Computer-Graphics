from tkinter import *

coords = []

def drawLine(x1,y1,x2,y2):
    px = x2 - x1
    py = y2 - y1

    sign_x = 1 if px > 0 else -1 if px < 0 else 0
    sign_y = 1 if py > 0 else -1 if py < 0 else 0

    if px < 0: px = -px
    if py < 0: py = -py

    if px > py:
        pdx, pdy = sign_x, 0
        es, el = py, px
    else:
        pdx, pdy = 0, sign_y
        es, el = px, py

    x, y = x1, y1

    error, t = el / 2, 0

    img.put("#000000", (x,y))

    while t < el:
        error -= es
        if error < 0:
            error += el
            x += sign_x
            y += sign_y
        else:
            x += pdx
            y += pdy
        t += 1
        img.put("#000000", (x,y))

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