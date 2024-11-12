import cadquery as cq
import math
import json 

with open("parameters.json", mode="r", encoding="utf-8") as read_file:
        parameter_data = json.load(read_file)

# load arameters for the piping from json file
num_points = 1
outer_radius = 1
inner_radius =1
cake_radius = 1

print("Parameter Data:", parameter_data.type())
# List to hold points
# points = []

# # Calculate the angle between each point
# angle_step = math.pi / num_points

# # Generate points for the star shape to be vertical
# for i in range(2 * num_points):
#     radius = outer_radius if i % 2 == 0 else inner_radius
#     y = radius * math.cos(i * angle_step)
#     z = radius * math.sin(i * angle_step)
#     points.append((y, z))

# result = (cq.Workplane("YZ")
#           .polyline(points)
#           .close()
#           .twistExtrude(100, 900)
#          )
#form circle with extrusion

