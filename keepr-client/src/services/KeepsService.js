import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    console.log(res.data)
    AppState.keeps = res.data
  }

  // async getOne(id) {
  //   const res = await api.get('api/keeps/' + id)
  //   AppState.activeKeep = res.data
  //   console.log(AppState.activeKeep)
  // }
}

export const keepsService = new KeepsService()
