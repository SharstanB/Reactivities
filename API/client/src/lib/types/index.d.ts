type Activity = {
    id: string
    description: string
    date: Date
    title: string
    isCancelled: boolean
    cityName: string
    venue: string
    latitude: number
    longitude: number
    categoryName: string
    categoryId: string
    cityId: string
};

type BasicListObject = {
    id: string
    name : string
}

// type ActivityLists = {
//     activities : Activity[],
//     cities: BasicListObject[],
//     categories: BasicListObject[]
// }