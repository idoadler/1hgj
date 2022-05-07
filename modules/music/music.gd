extends Area2D

var active = true
var on_but
var off_but
var stream


# Called when the node enters the scene tree for the first time.
func _ready():
	on_but = get_node("on")
	off_but = get_node("off")
	stream = get_node("stream")
	set_state(active)


func _input_event(viewport, event, shape_idx):
	if event is InputEventMouseButton:
		if event.pressed and event.button_index == 1:
			set_state(!active)

func set_state(state):
	active = state
	on_but.visible = active
	off_but.visible = !active
	stream.stream_paused = !active
