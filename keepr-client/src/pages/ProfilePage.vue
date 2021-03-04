<template>
  <!-- <div class="home flex-grow-1 d-flex flex-column align-items-center justify-content-center"> -->
  <div class="container-fluid ProfilePage">
    <div class="row">
      <div class="col-2"></div>
      <div class="col-4"></div>
    </div>
    <div class="row">
      <div class="col-12">
        <h3>Vaults <i class="fa fa-plus text-success" aria-hidden="true"></i></h3>
      </div>
      <div class="col-12">
        <h3>Keeps <i class="fa fa-plus text-success" aria-hidden="true"></i></h3>
      </div>
    </div>
    <div class="row">
      <div class="col-12">
        <div class="masonry">
          <myKeeps-component v-for="r in state.keeps" :key="r.id" :keep-prop="r">
          </myKeeps-component>
        </div>
      </div>
    </div>
  </div>
  <!-- </div> -->
</template>

        // <div class="masonry">
        //   <myVaults-component v-for="r in state.vaults" :key="r.id" :keep-prop="r">
        //   </myVaults-component>
        // </div>

<script>
import { onMounted, reactive, computed } from 'vue'
import { keepsService } from '../services/KeepsService'
import { vaultsService } from '../services/VaultsService'
import { logger } from '../utils/Logger'
import { useRoute } from 'vue-router'
import { AppState } from '../AppState'
export default {
  name: 'ProfilePage',
  setup() {
    const route = useRoute()
    const state = reactive({
      vaults: computed(() => AppState.myVaults),
      keeps: computed(() => AppState.myKeeps)
    })
    onMounted(async() => {
      try {
        await vaultsService.getMyVaults(route.params.id)
      } catch (error) {
        logger.log(error)
      }
      try {
        await keepsService.getMyKeeps(route.params.id)
      } catch (error) {
        logger.log(error)
      }
    })
    return {
      state
    }
  }
}
</script>

<style>
.masonry {
  column-count: 4;
  column-gap: 1em;
}

.item { /* Masonry bricks or child elements */
  background-color: #eee;
  display: inline-block;
  margin: 0 0 1em;
  width: 100%;
}

</style>
