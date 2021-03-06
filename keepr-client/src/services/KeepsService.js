import { AppState } from '../AppState'
import { api } from './AxiosService'

class KeepsService {
  async getKeeps() {
    const res = await api.get('api/keeps')
    console.log(res.data)
    AppState.keeps = res.data
  }

  async getMyKeeps(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    console.log(res.data)
    AppState.myKeeps = res.data
  }

  async createKeep(newKeep) {
    await api.post('api/keeps', newKeep)
  }

  // DON'T NEED THIS, IS HANDLED ON THE BACKEND
  // async increment(keep) {
  //   const updated = { keeps: keep.keeps++ }
  //   await api.put('api/keeps/' + keep.id, updated)
  // }
  // { await api.delete('api/vaultkeeps/' + keepProp.vaultKeepId) }

  async deleteKeep(keep) {
    console.log(keep)
    if (confirm('Confirm deletion?')) { await api.delete('api/keeps/' + keep.id) }
    // this.getTasks(task.list)
  }

  //     if (confirm('Confirm deletion?')) { await api.delete('api/vaultkeeps/' + id) }

  //   async getMyVaults(id) {
  //   const res = await api.get('api/profiles/' + id + '/vaults')
  //   // unsure if correct right now
  //   console.log(res.data)
  //   AppState.vaults = res.data
  // }

  // async getOne(id) {
  //   const res = await api.get('api/keeps/' + id)
  //   AppState.activeKeep = res.data
  //   console.log(AppState.activeKeep)
  // }
}

export const keepsService = new KeepsService()
