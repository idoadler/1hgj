extends Node2D


var speed = 20
var direction = Vector2(1.0, 0.0)
var moving = false

var arrow
var arrowStanding
var bow
var bowShoot

# Called when the node enters the scene tree for the first time.
func _ready():
	arrow = get_node("ArrowRunning")
	arrowStanding = get_node("Bow/Arrow")
	bow = get_node("Bow/Bow")
	bowShoot = get_node("Bow/Bow2")


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	arrow.visible = moving
	arrowStanding.visible = not moving
	bow.visible = not moving
	bowShoot.visible = moving
	if(moving):
		arrow.position += direction * speed * delta

func _unhandled_input(event):
	if event is InputEventKey:
		if event.pressed and event.scancode == KEY_SPACE:
			moving = true
