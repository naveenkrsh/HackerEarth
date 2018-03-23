q = int(input().strip())

s1 = []
s2 = []
s3 = []
s4 = []


def getSchoolQueue(num):
    if num == 1:
        return s1
    if num == 2:
        return s2
    if num == 3:
        return s3
    if num == 4:
        return s4


queue = []
counter = 0

while counter < q:
    inp = input().strip().split()
    o = inp[0]

    if o == "E":
        s = int(inp[1])
        r = int(inp[2])
        if (s in queue) == False:
            queue.append(s)
        arr = getSchoolQueue(s)
        arr.append((s,r))
    else:
        schoolNo = queue[0]
        arr = getSchoolQueue(schoolNo)
        sel = arr.pop(0)
        if len(arr)== 0:
            queue.pop(0)
        print(str(sel[0]) + " " + str(sel[1]))

    counter = counter + 1
