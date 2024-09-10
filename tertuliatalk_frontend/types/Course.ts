
export type CreateCourse =  {
    title: string,
    description: string,
    type: string,
    participants?: number,
    maxParticipant?: number,
    document?: any,
    startDate: string,
    duration: string,
}


export type Course = {
    id: string,
    title: string,
    description: string,
    type: string,
    participants: number,
    maxParticipant: number,
    document: string,
    startDate: string,
    duration: string,
}
