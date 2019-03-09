import axios from 'axios'

export default class CardService {
    static create(data, onSuccess, onError) {
        axios.post(``, data)
            .then(response => onSuccess(response))
            .catch(err => onError(err))
    }
}