def solution(max_weight, specs, names):
    specs_dict = {}
    for spec in specs:
        specs_dict[spec[0]] = int(spec[1])
    trucks = 1
    weight = 0
    for name in names:
        if weight + specs_dict[name] <= max_weight:
            weight += specs_dict[name]
        else:
            trucks += 1
            weight = specs_dict[name]

    return trucks