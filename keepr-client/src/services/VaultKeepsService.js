// import { AppState } from '../AppState'
import { api } from './AxiosService'

class VaultKeepsService {
  async removeKeepFromVault(id) {
    console.log(id)
    if (confirm('Confirm deletion?')) { await api.delete('api/vaultkeeps/' + id) }
    // this.getNotes(note.bug)
  }

  async createVaultKeep(keep, newVaultId) {
    console.log(keep, newVaultId)
    await api.post('api/vaultkeeps', { keepId: keep.id, vaultId: newVaultId })
  }

  // async createVaultKeep(ids) {
  //   console.log(ids)
  //   await api.post('api/vaultkeeps', ids)
  // }
}

export const vaultKeepsService = new VaultKeepsService()
