function settleGuests(availableRooms, guests) {
  let rooms = extractRooms(availableRooms)
  let guestsWithoutRooms = 0

  for (let couple of guests) {
    let roomFound = false

    if (couple.first.gender != couple.second.gender) {
      roomFound = settleDifferentSex(couple, roomFound)
    } else {
      roomFound = settleSameSex(couple, roomFound)
    }
    if (!roomFound) {
      guestsWithoutRooms += couple.first ? 2 : 1
    }
  }
  printReport()

  function settleSameSex(couple, roomFound) {
    for (let room of [...rooms.values()].filter(r => r.type == 'triple')) {
      if (room.emptyBeds >= 2) {
        if (!room.guests) {
          room.guests = []
        } else if (room.guests[0].gender != couple.second.gender) {
          continue
        }

        if (couple.first) {
          settleSingleGuest(couple.first, room)
        }

        settleSingleGuest(couple.second, room);
        roomFound = true
        break
      } else if (room.emptyBeds == 1) {
        if (room.guests[0].gender == couple.second.gender) {
          settleSingleGuest(couple.first ? couple.first : couple.second, room)
          couple.first = undefined
        }
      }
    }
    return roomFound

  }

  function settleSingleGuest(guest, room) {
    room.guests.push(guest);
    room.emptyBeds -= 1;
  }

  function settleDifferentSex(couple, roomFound) {
    let room = [...rooms.values()].find(r => r.type === 'double-bedded' && r.emptyBeds == 2)
    if (room) {
      room.guests = []
      room.guests = [couple.first, couple.second]
      room.emptyBeds = 0
      roomFound = true

      return roomFound
    }
  }

  function extractRooms(availableRooms) {
    let rooms = new Map()
    for (let currentRoom of availableRooms) {
      let beds = currentRoom.type === 'double-bedded' ? 2 : 3
      rooms.set(currentRoom.number, { type: currentRoom.type, emptyBeds: beds })
    }
    return rooms
  }

  function printReport() {
    for (let [number, room] of [...rooms].sort()) {
      console.log(`Room number: ${number}`)
      if (room.guests) {
        for (let guest of room.guests.sort(guestsComparator())) {
          console.log(`--Guest Name: ${guest.name}`)
          console.log(`--Guest Age: ${guest.age}`)
        }
      }
      console.log(`Empty beds in the room: ${room.emptyBeds}`)
    }
    console.log(`Guests moved to the tea house: ${guestsWithoutRooms}`)

    function guestsComparator() {
      return function (a, b) {
        return a.name.toLowerCase().localeCompare(b.name.toLowerCase());
      };
    }
  }

}

const rooms1 = [
  { number: '101A', type: 'double-bedded' },
  { number: '104', type: 'triple' },
  { number: '101B', type: 'double-bedded' },
  { number: '102', type: 'triple' }
]

const rooms2 = [
  { number: '206', type: 'double-bedded' },
  { number: '311', type: 'triple' }
]

const guests1 = [
  {
    first: { name: 'Sushi & Chicken', gender: 'female', age: 15 },
    second: { name: 'Salisa Debelisa', gender: 'female', age: 25 }
  },
  {
    first: { name: 'Daenerys Targaryen', gender: 'female', age: 20 },
    second: { name: 'Jeko Snejev', gender: 'male', age: 18 }
  },
  {
    first: { name: 'Pesho Goshov', gender: 'male', age: 20 },
    second: { name: 'Gosho Peshov', gender: 'male', age: 18 }
  },
  {
    first: { name: 'Conor McGregor', gender: 'male', age: 29 },
    second: { name: 'Floyd Mayweather', gender: 'male', age: 40 }
  }
]
const guests2 = [
  {
    first: { name: 'Tanya Popova', gender: 'female', age: 24 },
    second: { name: 'Miglena Yovcheva', gender: 'female', age: 23 }
  },
  {
    first: { name: 'Katerina Stefanova', gender: 'female', age: 23 },
    second: { name: 'Angel Nachev', gender: 'male', age: 22 }
  },
  {
    first: { name: 'Tatyana Germanova', gender: 'female', age: 23 },
    second: { name: 'Boryana Baeva', gender: 'female', age: 22 }
  }
]

settleGuests(
  rooms1,
  guests1
)

//settleGuests(
//   rooms2,
//   guests2
// )