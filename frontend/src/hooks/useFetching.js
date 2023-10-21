import {useState} from "react";

export const useFetching = (callback) => {
    const [isLoading, setIsLoading] = useState(false)
    const [error, setError] = useState('')

    const fetching = async () => {
        try{
            console.log('start')
            setIsLoading(true)
            await callback()
        } catch(e) {
            setError(e.message)
        } finally {
            setIsLoading(false)
            console.log('finish')
        }
    }

    return [fetching, isLoading, error]
}