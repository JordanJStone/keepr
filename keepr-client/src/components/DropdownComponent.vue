<template>
  <a class="dropdown-item" href="#" @click.prevent="editKeep(keepProp, vaultProps.id)">{{ vaultProps.name }}</a>
</template>

<script>
import { keepsService } from '../services/KeepsService'
import { logger } from '../utils/Logger'
export default {
  name: 'DropdownComponent',
  props: {
    vaultProps: { type: Object, required: true },
    keepProp: { type: Object, required: true }
  },
  setup() {
    return {
      editKeep(keep, newVaultId) {
        try {
          keepsService.editTask(keep, newVaultId)
        } catch (error) {
          logger.log(error)
        }
      }
    }
  }
}
</script>

<style lang="scss" scoped>

</style>
