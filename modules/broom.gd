extends Area2D

var screenSize
var scene = load("res://modules/broom.tscn")
var alive = true
var speed = 3
var target
var sea
var water = true

func _ready():
	target = get_node("/root/Game/target")
	sea = get_node("/root/Game/sea")
	screenSize = get_viewport().get_visible_rect().size
	var random_x = randi() % int(screenSize.x)
	var random_y =  randi() % int(screenSize.y)
	var random_pos = Vector2(random_x, random_y)
	position=random_pos
	

func _process(delta):
	if sea.position.y <= 64:
		return
	if(alive and water):
		position = position.move_toward(target.position, delta * speed)
		if position.distance_to(target.position) < 10:
			water = false
			yield(get_tree().create_timer(3.0), "timeout")
			if sea.position.y > 64:
				sea.position.y -= 1
			water = true

func _input_event(viewport, event, shape_idx):
	if sea.position.y <= 64:
		return
	if alive:
		if event is InputEventMouseButton:
			if event.pressed and event.button_index == 1:
				duplicate_broom()

func duplicate_broom():
	alive = false
	rotation = 90
	yield(get_tree().create_timer(1.0), "timeout")
	if sea.position.y <= 64:
		return
	var instance
	instance = scene.instance()
	get_tree().root.add_child(instance)
	yield(get_tree().create_timer(1.0), "timeout")
	if sea.position.y <= 64:
		return
	instance = scene.instance()
	get_tree().root.add_child(instance)
