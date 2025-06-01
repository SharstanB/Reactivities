import {z} from 'zod'

const requiredString = (fieldName : string) => z.string({message:`${fieldName} is required`}).min(1, 
    {message: `${fieldName} is required`});

export const activitySchema = z.object({
    title : requiredString('title'),
    description : requiredString('description'),
    date : requiredString('date'),
    venue : requiredString('venue'),
    city : requiredString('city'),
    category : requiredString('category'),
})


export type ActivitySchema = z.infer<typeof activitySchema>